package http

import (
	"encoding/base64"
	"encoding/json"
	"net/http"
	"net/http/httptest"
	"testing"

	"github/vanjiii/golang/fndy"
	"github/vanjiii/golang/fndy/file"
	"github/vanjiii/golang/fndy/service"

	"github.com/gofrs/uuid"
	"github.com/golang/mock/gomock"
)

var any = gomock.Any()

func TestFile(t *testing.T) {
	t.Run("search", testSearch)
}

func testSearch(t *testing.T) {
	env := service.NewTestEnv(t)

	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()
	mf := file.NewMockFiler(mockCtrl)

	file := fndy.File{
		ID:      uuid.Nil,
		Name:    "f",
		AppName: fndy.AppMobile,
		OS:      fndy.OSLinux,
		Version: 1,
	}

	mf.EXPECT().Search(any, any, any).Return([]fndy.File{file}).AnyTimes()
	env.FileHandler = mf

	cases := []struct {
		name string
		user string
		pass string
		code int
	}{
		{
			name: "ok",
			user: "user",
			pass: "secret123",
			code: http.StatusOK,
		},
		{
			name: "unauth",
			user: "user",
			pass: "123",
			code: http.StatusUnauthorized,
		},
	}

	for _, c := range cases {
		t.Run(c.name, func(t *testing.T) {
			router := ServeMux(env)
			r := httptest.NewRequest("GET", "/search", nil)
			w := httptest.NewRecorder()

			r.Header.Add("Authorization", "Basic "+basicAuth(c.user, c.pass))

			router.ServeHTTP(w, r)

			if w.Code != c.code {
				t.Fatalf("exp: %v, but got: %v", http.StatusOK, w.Code)
			}

			if c.code != http.StatusOK {
				// skip additional checks
				return
			}

			var fs []fndy.File
			if err := json.NewDecoder(w.Body).Decode(&fs); err != nil {
				t.Fatalf("decoding failed: %s", err)
			}

			if len(fs) != 1 {
				t.Fatalf("expected one file but got diff")
			}
		})
	}
}

func basicAuth(username, password string) string {
	auth := username + ":" + password
	return base64.StdEncoding.EncodeToString([]byte(auth))
}
