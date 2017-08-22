'''
Във файл reverse_int.py, напишете програма, която:

Чете едно цяло число n от потребителя
На екрана извежда числото n, записано в обратен ред на своите цифри.
'''

n = int(input("Enter n: "))

result = ""

while n != 0:
	digit = n % 10
	n = n // 10
	result += str(digit)

print(result)