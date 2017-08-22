'''
Два цели прости числа p, и q се наричат близнаци, ако е изпълнено p = q + 2

Например:

3 и 5 са прости числа близнаци.
5 и 7 са прости близнаци.
Във файл twin_prime.py, напишете програма, която:

Чете едно цяло число p
Изкарва на екрана неговото просто число близнак, ако има такова. Може да има повече от 1 просто число близнак.
Ако числото p не е просто или пък няма прост близнак, програмата казва, че няма близнак.

'''
import math

p = int(input("Enter p: "))
smaller_twin = 0
bigger_twin = 0

#check if p is prime
i = 5
isPrime = True

if p == 2 or p == 3 or p == 1:
	isPrime = True
elif p % 2 == 0 or p % 3 == 0:
	isPrime = False

while i <= (p - 1):
	if p % i == 0:
		isPrime = False
	i += 1

if not isPrime:
	print("The number is not prime!")
else:
	print("Twin prime with {}: ".format(p))
	#find if p has bigger twin bro's
	q = p + 2

	i = 2
	has_prime_twin = True

	while i <= (q - 1):
		if q % i == 0:
			has_prime_twin = False
		i += 1
	
	if has_prime_twin:
		print("{}, {}".format(q, p))
	else:
		print("{} is not prime". format(q))
	#find if p has smaller twin bro's
	q = p - 2

	i = 2
	has_prime_twin = True

	while i <= (q - 1):
		if q % i == 0:
			has_prime_twin = False
		i += 1

	if has_prime_twin:
		print("{}, {}".format(p, q))
	else:
		print("{} is not prime". format(q))