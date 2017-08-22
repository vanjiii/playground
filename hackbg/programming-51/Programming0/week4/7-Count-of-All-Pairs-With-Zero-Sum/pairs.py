
def count_zero_pairs(numbers):
	index = 0
	result = 0

	while index < (len(numbers)):
		ind = index
		while ind < len(numbers):
			if numbers[ind] + numbers[index] == 0:
				result += 1
			ind += 1
		index += 1
	return result

print(count_zero_pairs([0, 2, -2, 5, 10]))