'''
Във файл avg.py, напишете програма, която:

Чете едно число n от потребителя.
На следващите n реда чете по едно число от потребителя.
Накрая изкарва средното аритметично на всички въведени числа.
Средното аритметично се определя като разделим сумата на всички числа върху техния брой
'''

n = int(input("Enter n: "))

count = 0
all_numbers = []

while count < n:
	number = int(input("Enter a number: "))
	all_numbers += [number]
	count += 1

sum_all = 0

for num in all_numbers:
	sum_all += num

print("The Average sum is: {}".format(sum_all / len(all_numbers)))