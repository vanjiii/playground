'''
Във файла large_and_small.py напишете програма, която:

Чете едно цяло число n от потребителя
На екрана извежда най-голямото число, което може да се получи със същите цифри от n
На екрана извежда най-малкото число, което може да се получи със същите цифри от n
n може да е произволно голямо число, като направете решение за число, в което няма да цифрата 0.
'''

def large_and_small(number):
	number_arr = []
	result = []
	big_number = ""
	small_number = ""

	while number != 0:
		digit = number % 10
		number = number // 10
		number_arr += [digit]

	number_arr.sort()
	for num in number_arr:
		big_number += str(num)

	number_arr.reverse()
	for num in number_arr:
		small_number += str(num)

	result = result + [int(big_number)] + [int(small_number)]

	return result


#main
#a = int(input("Enter a n: "))
#print(large_and_small(a))