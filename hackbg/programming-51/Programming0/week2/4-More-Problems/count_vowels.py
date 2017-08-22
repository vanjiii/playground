'''
Имаме следната задача:

Дават ни някакъв низ (string) на английски език от входа
Трябва да кажем броят на гласните букви в низа, като броим и главни и малки букви.
Наприме в низа "I am a very very man" имаме 8 гласни - I, a, a, e, y, e, y, a.

Всички гласни букви, големи и малки, в английската азбука са: "aeiouyAEIOUY"

Във файл count_vowels.py, напишете програма, която:

Чете един низ от потребителския вход
Изкарва на екрана броят на големите и малките гласни в низа.
'''

string = input("Enter a str: ")

#vowels = "aeiouyAEIOUY"
a = "a"
e = "e"
i = "i"
o = "o"
u = "u"
y = "y"

idx = 0
count = 0

while idx < len(string):
	if a == string[idx].lower() or e == string[idx].lower() or i == string[idx].lower() or o == string[idx].lower() or u == string[idx].lower() or y == string[idx].lower():
		count += 1
	idx += 1

'''
for ch in string:
	if ch in vowels:
		count += 1	
'''

print("Numbers of vowels are: {}".format(count))