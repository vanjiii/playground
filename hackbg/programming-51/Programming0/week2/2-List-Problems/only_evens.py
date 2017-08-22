'''
Във файл only_evens.py, напишете програма, която:

Чете едно число n от потребителя
На следващите n реда чете по едно число
Първо, програмата изкарва на екрана броят на четните числа.
Накрая принтира на екрана само четните числа, от въведените от потребителя
'''

n = int(input("Enter n: "))

count = 0
all_numbers = []

while count < n:
	number = int(input("Enter a number: "))
	all_numbers += [number]
	count += 1

count = 0
#even numbers
for num in all_numbers:
	if num % 2 == 0:
		print(num)
		count += 1

print("The count of the even numbers is: {}".format(count))