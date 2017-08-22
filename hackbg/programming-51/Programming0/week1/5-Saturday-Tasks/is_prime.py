'''
Във файл is_prime.py, напишете програма, която:

Чете едно цяло число n от потребителя
Изкарва на екрана съобщение, ако числото е просто - The number is prime!
Иначе изкарва съобщение - The number is not prime!
'''

import math

n = int(input("Enter n: "))

i = 5
isPrime = True

if n == 2 or n == 3 or n == 1:
	isPrime = True
elif n % 2 == 0 or n % 3 == 0:
	isPrime = False

while i <= (n - 1):
	if n % i == 0:
		isPrime = False
	i += 1

if isPrime:
	print("It is prime")
else:
	print("It is not prime")