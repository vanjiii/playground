from random import randint

def generate_random_list(n, start, end):
	ind = 0
	result = []
	while ind < n:
		result += [randint(start, end)]
		ind += 1
	return result

#main
print(generate_random_list(5, 1, 3))