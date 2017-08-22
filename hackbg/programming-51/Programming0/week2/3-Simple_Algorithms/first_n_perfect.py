'''
Във файл first_n_perfect.py, напишете програма, която:

Чете едно цяло число n
На екрана изкарва първите n на брой перфектни числа.
'''

n = int(input("Enter a number: "))

print("The perfect numbers: ")

cnt = 2

while cnt < n:
	count = 1
	sum_of_divisors = 0

	while count < cnt:
		if cnt % count == 0:
			sum_of_divisors += count
		count += 1

	if sum_of_divisors == cnt:
		print(cnt)

	cnt += 1