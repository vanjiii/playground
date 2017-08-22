'''
Във файл max_of_n.py, напишете програма, която:

Чете едно число n от потребителя.
На следващите n реда, чете по едно число от потребителя.
Накрая изкарва максималното число от всички въведени.
'''
n = int(input("Enter n: "))

count = 0
all_numbers = []

while count < n:
	number = int(input("Enter a number: "))
	all_numbers += [number]
	count += 1

max_num = 0

for num in all_numbers:
	if max_num < num:
		max_num = num

print("The max num is: {}".format(max_num))