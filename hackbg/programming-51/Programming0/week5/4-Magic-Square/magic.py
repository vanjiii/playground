
def magic_square(square):
	#get value for first row
	sum_row = 0
	for item in square[0]:
		sum_row += item

	#rows
	for row in square:
		temp_sum = 0
		for element in row:
			temp_sum += element
		if temp_sum != sum_row:
			return False

	#columns
	index = 0		
	while index < len(square):
		temp_sum = 0
		i = 0
		while i < len(square):
			temp_sum += square[i][index]
			i += 1

		if temp_sum != sum_row:
			return False
		index += 1

	#diagonals
	index = 0
	sum_d1 = 0
	sum_d2 = 0
	while index < len(square):
		sum_d1 += square[index][index]
		sum_d2 += square[(len(square) - 1) - index][(len(square) - 1) - index]
		index += 1

	if sum_d1 != temp_sum or sum_d2 != temp_sum:
		return False

	#this means the square is magic
	return True

#main
s = [
	[23, 28, 21],
	[22, 24, 26],
	[27, 20, 25]
]
print(magic_square(s))