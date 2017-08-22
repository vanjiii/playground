'''
Ако имаме едно цяло число n, то всички делети на това число са тези числа между 1 и n - 1, които се делят на n без остатък.

Например, ако n = 6, то всички делители са:

1, защото 6 % 1 == 0
2, защото 6 % 2 == 0
3, защото 6 % 3 == 0
Във файл divisors.py, напишете програма, която:

Чете едно цяло число n
Изкарва списък от всички делители на n, без самото n.
'''

n = int(input("Enter a number: "))

count = 1
number_of_occ = 0
all_divisors = []

if n > 0:
	while count < n:
		if n % count == 0:
			number_of_occ += 1
			all_divisors += [count]
		count += 1
elif n < 0:
	count = -1
	while count > n:
		if n % count == 0:
			number_of_occ += 1
			all_divisors += [count]
		count -= 1
else:
	print("Please enter next time number different of zero!")

print("Numbers of divisors are: {}".format(number_of_occ))
print("All divisors are =>")
for div in all_divisors:
	print(div)