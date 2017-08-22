'''
Във файла in_interval.py, напишете програма, която:

Чете едно число от потребителя - a, което е долна граница на интервал.
Чете второ число от потребителя - b, която е горна граница на интервал.
Чете трето число от потребителя - x и:

Ако числото x е равно на a, изпринтете: "The number is equal to the lower bound of the interval"
Ако числото x е равно на b, изпринтете: "The number is equal to the upper bound of the interval"
Ако числото x е: а < x < b, изпринтете: "The number is in the interval"
Ако числото x < a, изпринтете: "The number is outside the interval, x < a"
В противен случай, ако x > b, изпринтете: "The number is outside the interval, x > b"
'''

a = input("Enter the first number: ")
a = int(a)
b = input("Enter the second number: ")
b = int(b)
x = input("Enter the third number: ")
x = int(x)


if x == a:
	print("The number is equal to the lower bound of the interval")
elif x == b:
	print("The number is equal to the upper bound of the interval")
elif a < x and x < b:
	print("The number is in the interval")
elif a > x: 
	print("The number is outside the interval, x < a")
else:
	print("The number is outside the interval, x > b")
