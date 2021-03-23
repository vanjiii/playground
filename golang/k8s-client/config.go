package client

type Config struct {
	IP   string
	Port int

	UKey  string
	UCert string
	CA    string
}

func NewConfig(port int, ip, userKey, userCert, certAuth string) Config {
	return Config{
		IP:    ip,
		Port:  port,
		UKey:  userKey,
		UCert: userCert,
		CA:    certAuth,
	}
}
