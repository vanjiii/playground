'''
Във файла evenodd.py, напишете програма, която:

Чете от потребителя дадено число
Отпечатва на екрана дали това число е четнои ли нечетно.
'''

a = input("Enter a number: ")
a = int(a)

if a % 2 == 0:
	print("The number is even!")
else:
	print("The number is odd!")
