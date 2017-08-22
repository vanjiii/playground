'''
Нека да имаме следния списък:

languages = ["Python", "Ruby"]
Напишете изрази или statements в Python REPL, които:

Добавят към списъка languages, след "Ruby", езиците C++, Java и C#.
Добавят като първи елемент в списъка languages, езикът Haskell
Добавят като последен елемент във вече променения списък с нещата отгоре, езикът Go.
След като сте променили списъкът languages с нещата от по-горе, напишете изрази, които:

Връщат първия елемент на списъка
Връщат втория елемент на списъка
Връщат петия елемент на списъка
Променят елемента със стойност "C#" с нова стойност - F#
Връщат последния елемент на списъка. Може ли да решите това чрез функцията len ?
След като сте готови и с тази задача, напишете израз, които проверяват дали:

Езикът Haskell се намира в списъка languages
Езикът Ruby се намира в списъка languages
Езикът Go се намира в списъка languages
Езикът Rust се намира в списъка languages
'''

languages = ["Python", "Ruby"]

languages += ["C++"]
languages += ["Java"]
languages += ["C#"]

languages = ["Haskell"] + languages

languages += ["Go"]

print(languages[0])
print(languages[1])
print(languages[4])

count = 0
for item in languages:
	if item == "C#":
		break
	count += 1

languages[count] = "F#"

print(languages[len(languages) - 1])

if "Haskell" in languages:
	print("Haskell is one of the languages")
else:
	print("Haskell is not one of the languages")
if "Ruby" in languages:
	print("Ruby is one of the languages")
else:
	print("Ruby is not one of the languages")
if "Rust" in languages:
	print("Rust is one of the languages")
else:
	print("Rust is not one of the languages")
if "Go" in languages:
	print("Go is one of the languages")
else:
	print("Go is not one of the languages")

print(languages)

