'''
Във файл min_of_n.py, напишете програма, която:

Чете едно число n от потребителя.
На следващите n реда, чете по едно число от потребителя.
Накрая изкарва мининалното число от всички въведени.
'''
n = int(input("Enter n: "))

count = 0
all_numbers = []

while count < n:
	number = int(input("Enter a number: "))
	all_numbers += [number]
	count += 1

min_num = 999999999999

for num in all_numbers:
	if min_num > num:
		min_num = num

print("The min num is: {}".format(min_num))
