'''
Във файл prime_digit.py, напишете програма, която:

Чете едно цяло число n
Изкарва на екрана Да или Не ако в числото, има поне 1 цифра, което да е просто число.

Например, за числото 99448, няма нито 1 цифра, която да е просто число.

В числото 123, цифрата 3 е просто число.
'''

n = int(input("Enter a number: "))

has_prime = False

while n != 0:
	digit = n % 10
	n = n // 10

	#check is the digit prime
	if digit == 1 or digit == 2 or digit == 3 or digit == 5 or digit == 7:
		has_prime = True
		break

if has_prime:
	print("ДА")
else:
	print("НЕ")