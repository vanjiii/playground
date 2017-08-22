
def hash_them(keys, values):
	hsm = {}

	if len(keys) >= len(values):
		index = 0

		for k in keys:
			if index < len(values):
				hsm[k] = values[index]
			else:
				hsm[k] = None

			index += 1

	else:
		print("The second list must be at least with the same lenght as the first!")

	return hsm

print(hash_them(["Ivan", "Maria"], [1, 2]))
print(hash_them(["Ivan", "Maria"], [1]))
