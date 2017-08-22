'''
Във файл largest_3_digits.py, напишете програма, която:

Чете едно цяло трицифрено число n от потребителя
На екрана изкарва най-голямото число, което може да се получи със същите 3 цифри на n
На екрана изкарва най-малкото число, което може да се получи със същите 3 цифри на n
'''

num = int(input("Enter a 3-digit number: "))

min_digit = 0
max_digit = 0
middle_digit = 0

while num != 0:
	temp = num % 10
	num = num // 10

	if temp > max_digit:
		temp, max_digit = max_digit, temp
		min_digit = temp
	if temp > middle_digit:
		temp, middle_digit = middle_digit, temp
		min_digit = temp
	else:
		min_digit = temp

print("The biggest number is {}{}{}".format(max_digit, middle_digit, min_digit))
print("The smallest number is {}{}{}".format(min_digit, middle_digit, max_digit))

