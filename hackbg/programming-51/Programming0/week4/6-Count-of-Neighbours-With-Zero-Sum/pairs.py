
def count_zero_neighbours(numbers):
	index = 0
	result = 0

	while index < (len(numbers) - 1):

		if numbers[index] + numbers[index + 1] == 0:
			result += 1
			#print(numbers[index])

		index += 1

	return result


print(count_zero_neighbours([1, 2, -2, 0, 0, 5, -5]))