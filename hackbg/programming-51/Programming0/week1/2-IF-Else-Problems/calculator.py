'''
Във файл, който се казва calculator.py, напишете следната програма:

Чете от потребител, първото число a
Чете от потребител, второто число b
Чете от потребител, операцията oper, която може да е или +, -, *, и /.
Програмата трябва да направи следното нещо:

Изкарва на екрана резултатът от получения израз: a oper b.
Ако получи неизвестна операция, да каже за това.
'''

a = input("Enter a: ")
a = int(a)
b = input("Enter b: ")
b = int(b)
oper = input("Enter operator (+, -, *, /)")

if oper == "+":
	print("a + b = {}".format(a + b))
elif oper == "-":
	print("a - b = {}".format(a - b))
elif oper == "*":
	print("a * b = {}".format(a * b))
elif oper == "/":
	print("a / b = {}".format(a / b))
else:
	print("Invalid operator!")