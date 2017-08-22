'''
Във файла int_functions.py, напишете програма, която дефинира следните функции:

reverse_int(n) - взима едно число и го връща в обърнато. Например 123 е 321
sum_digits(n) - намира сумата на всички цифри в n
product_digits(n) - намира произведението на всички цифри в n
В програмата прочете едно число и отпечатайте резултатът от прилагането на горните функции върху него.
'''

def reverse_int(n):
	result = 0
	count = 0

	while n != 0:
		digit = n % 10
		n = n // 10 
		result = (result * 10) + digit
		count += 1

	return result

def sum_digits(n):
	result = 0

	while n != 0:
		digit = n % 10
		n = n // 10
		result += digit

	return result


def product_digits(n):
	result = 1

	while n != 0:
		digit = n % 10
		n = n // 10
		result = result * digit

	return result


#main 
n = int(input("Enter a number: "))

print("Reverse int: {}".format(reverse_int(n)))
print("Sum of the digits: {}".format(sum_digits(n)))
print("Product of the digits: {}".format(product_digits(n)))