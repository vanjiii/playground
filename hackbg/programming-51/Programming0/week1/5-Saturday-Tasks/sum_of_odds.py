'''
Във файла sum_of_odds.py напишете програма, която:

Чете едно число n от потребителя.
На екрана изкарва сумата на всички нечетни числа между 1 и n включително.
'''

n = input("Enter n: ")
n = int(n)

i = 1
sum = 0

while i <= n:
	if i % 2 == 1:
		sum += i
	i += 1

print("sum: " + str(sum))