
def prime_pair(numbers):
	index = 0

	while index < (len(numbers)):
		ind = index
		while ind < len(numbers):
			if is_prime(numbers[ind] + numbers[index]):
				return True
			ind += 1
		index += 1
	return False

def is_prime(n):
	if n == 2 or n == 3:
		return True
	if n % 2 == 0 or n % 3 == 0:
		return False

	index = 5

	while index < n:
		if n % index == 0:
			return False

		index += 1


print(prime_pair([1, 2, 3, 4, 5]))