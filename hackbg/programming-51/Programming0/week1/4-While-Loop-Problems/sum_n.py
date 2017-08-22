'''
Във файл, с име sum_n.py, напишете програма, която:

Чете едно цяло число N от потребителя.
Принтира на екрана сумата на всички цели числа между 1 и N
'''

N = input("Enter N: ")
N = int(N)

sumOfAll = 0

'''
=============================================
count = 1 

while count <= N:
	sumOfAll += count
	count += 1
=============================================	
'''
middle = 0

if N % 2 == 1:
	sumOfAll = 1 + N
	middle = sumOfAll / 2
	sumOfAll = sumOfAll * (middle - 1) + middle
else:
	sumOfAll = 1 + N
	middle = N / 2
	sumOfAll = sumOfAll * middle

print("Sum: " + str(sumOfAll))