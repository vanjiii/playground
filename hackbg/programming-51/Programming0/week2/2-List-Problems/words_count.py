'''
Във файл words_count.py, напишете програма, която:

Чете на един ред от потребителя, дадена дума (string) word
Чете на следващия ред от потребителя едно число n
На следващите n реда, чете по 1 дума на ред.
Накрая, програмата изкарва броя на срещанията на думата word в тези n думи въведени от потребителя.
'''

word = input("Enter a word: ")

n = int(input("Enter a n: "))

count = 0
all_words = []

while count < n:
	w = input("Enter a word: ")
	all_words += [w]
	count += 1

count = 0

for wrd in all_words:
	if wrd == word:
		count += 1

print("The number of encounter is: {}".format(count))