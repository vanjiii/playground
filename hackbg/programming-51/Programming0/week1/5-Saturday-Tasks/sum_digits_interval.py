'''
Във файл sum_digits_interval.py, напишете програма, която:

Чете две цели числа N и M от потребителя.
Изкарва на екрана, за всяко число n между N и M включително, сумата на цифрите на n
'''
n = int(input("Enter n: "))
m = int(input("Enter m: "))

if n > m:
	while n >= m:

		sum_digits = 0

		local = m
		while local != 0:
			sum_digits += local % 10
			local = local // 10
		
		print("Number: {} and sum of digits: {}".format(m, sum_digits))
		m += 1
else:
	while m >= n:

		sum_digits = 0
		
		local = n
		while local != 0:
			sum_digits += local % 10
			local = local // 10
		
		print("Number: {} and sum of digits: {}".format(n, sum_digits))
		n += 1