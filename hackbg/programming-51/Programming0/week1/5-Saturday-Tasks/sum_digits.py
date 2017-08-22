'''
Във файл sum_digits.py, напишете програма, която

Чете от потребителя едно цяло число n
На екрана изкарва сумата на неговите цифри.
'''

n = input("Enter n: ")
n = int(n)

sum_digits = 0

while n != 0:
	sum_digits += n % 10
	n = n // 10
	#n = int(n)

print("sum: " + str(sum_digits))
