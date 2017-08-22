'''
Във файл sorted_names.py, напишете програма, която:

Чете едно число n от потребителя
На следващите n реда чете по 1 име от потребителя (string)
Накрая, програмата отпечатва всички въведени имена, подредени по азбучен ред в нарастващ ред (от a нагоре)
Може да разгледате какво прави функцията sorted в Python. Работи над списъци.
'''

n = int(input("Enter a n: "))

count = 0
all_words = []

while count < n:
	word = input("Enter a word: ")
	all_words += [word]
	count += 1

all_words.sort()

print(all_words)