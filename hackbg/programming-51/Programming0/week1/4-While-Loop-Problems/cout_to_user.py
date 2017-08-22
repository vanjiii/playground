'''
Във файл, който се казва count_to_user.py, напишете програма, която:

Чете от потребителя 1 число - n.
Принтира всички числa от 1 до n
След което принтира всички числа от n до 1
Всяко принтиране да е на нов ред.
'''

n = input("Enter n: ")
n = int(n)
i = 1

print("incrementing")
while i <= n:
	print(i)
	i += 1

print("decrementing")

while n >= 1:
	print(n)
	n -= 1