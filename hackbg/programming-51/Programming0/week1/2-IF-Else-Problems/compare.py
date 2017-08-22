'''
Във файл, който се казва compare.py, напишете следната програма:

Чете две числа от потребителя.
И спрямо следните условия, казва:

Кое от двете числа е по-голямо?
Ако са равни, казва, че числата са равни.
'''

a = input("Enter a: ")
a = int(a)
b = input("Enter b: ")
b = int(b)

if a > b:
	print("a is bigger!")
elif a < b:
	print("b is bigger!")
else:
	print("They are even!")