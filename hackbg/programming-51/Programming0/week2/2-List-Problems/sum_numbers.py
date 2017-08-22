'''
Във файл sum_numbers.py, напишете програма, която:

Чете едно число n от потребителя
На следващите n редам чете по едно число от потребителя
Накрая изкарва сумата на всички числа, които потребителят е въвел.
'''

n = int(input("Enter n: "))

count = 0
sum_of_all = 0

while count < n:
	number = int(input("Enter a number: "))
	sum_of_all += number
	count += 1

print("The sum is: {}".format(sum_of_all))
