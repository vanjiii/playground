'''
Във файл, int_palindrom.py, напишете програма, която:

Чете едно цяло число n от потребителя
Изкарва на екрана съобщение, ако числото е палиндром - The number is palindrom
В противен случай - The number is not palindrom
'''

n = int(input("Enter n: "))

result = ""
num = n

while n != 0:
	digit = n % 10
	n = n // 10
	result += str(digit)

result = int(result)

if result == num:
	print("The number is polyndrom")
else: 
	print("The number is NOT polyndrom")