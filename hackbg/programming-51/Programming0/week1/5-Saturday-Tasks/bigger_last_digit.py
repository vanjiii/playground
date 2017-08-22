'''
Във файл, който се казва bigger_last_digit.py, напишете програма, която:

Чете две цели числа от потребителя - n и m
На екрана извежда числото, което има по-голяма последна цифра от двете.
Ако последните цифри за равни, на екрана се извежда по-голямото число.
'''

n = input("Enter n: ")
n = int(n)

m = input("Enter m: ")
m = int(m)

n_last_digit = n % 10
m_last_digit = m % 10

if n_last_digit > m_last_digit:
	print("Has bigger last digit " + str(n))
elif n_last_digit < m_last_digit:
	print("Has bigger last digit " + str(m))
else: 
	if n > m:
		print("They are with equal last digit, but {} is bigger".format(str(n)))
	else:
		print("They are with equal last digit, but {} is bigger".format(str(m)))
