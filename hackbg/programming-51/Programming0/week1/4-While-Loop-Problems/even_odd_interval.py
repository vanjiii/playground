'''
Във файл, който се казва even_odd_interval.py, напишете програма, която:

Чете две числа от потребителя, които представляват интервал от цели числа.
За всяко число от интервала, изкарва на екрана самото число и съответно текст дали е четно или не.
'''

a = input("Enter a: ")
a = int(a)

b = input("Enter b: ")
b = int(b)

if a > b:
	while a >= b:
		if b % 2 == 0:
			print("Even - " + str(b))
		else:
			print("Odd - " + str(b))
		b += 1
else:
	while b >= a:
		if a % 2 == 0:
			print("Even - " + str(a))
		else:
			print("Odd - " + str(a))
		a += 1