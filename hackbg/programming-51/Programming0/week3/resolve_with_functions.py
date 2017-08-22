#returns all the divisors of a number
def divisors(n):
	result = []
	index = 1

	while index < n:
		if n % index == 0:
			result += [index]
		index += 1

	return result

#sum of all divisors of a number
def sum_ints(numbers):
	sum_divisors = 0

	divs = divisors(numbers)

	for div in divs:
		sum_divisors += div

	return sum_divisors

#checks if a number is perfect
def is_perfect(n):
	if sum_ints(n) == n:
		return True
	else:
		return False

#checks if a number is prime
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

	return True

#make a number into a list of his digits
def to_digits(n):
	result = []

	while n != 0:
		digit = n % 10
		n = n // 10
		result += [digit]

	return result

#main function
print(divisors(49))
print(sum_ints(49))

a = int(input("Enter a: "))
print(is_prime(as))