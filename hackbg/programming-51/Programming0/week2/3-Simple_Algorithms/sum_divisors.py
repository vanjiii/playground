'''
Във файл sum_divisors.py, напишете програма, която:

Чете едно число n
Изкарва сумата на всички негови делители, без n.
'''

n = int(input("Enter a number: "))

count = 1
sum_of_divisors = 0

while count < n:
	if n % count == 0:
		sum_of_divisors += count
	count += 1

print("The sum of the divisors are {}".format(sum_of_divisors))