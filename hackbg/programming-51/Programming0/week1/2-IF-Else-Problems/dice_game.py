'''
Във файл, който се казва dice_game.py, напишете програма, която прави следното:

Чете от потребител едно число N, което ще е броят на страните на зара
Чете името на първия играч.
Чете името на втория играч.
Хвърля зарове за първия и втория играч.
Имаме следните условия:

Играчът с по-голямо число, побежадава в играта. Програмата трябва да отпечата името на победителя"
Ако хвърлят едно и също число, програмата казва, че има равенство.
'''
from random import randint

number_of_sides = input("Enter how many sides has your dice: ")
number_of_sides = int(number_of_sides)

player_one = input("Enter player one's name: ")
player_two = input("Enter player two's name: ")

player_one_num = randint(1, number_of_sides)
player_two_num = randint(1, number_of_sides)

if player_one_num > player_two_num:
	print("Player {} wins {}".format(player_one, player_one_num))
elif player_one_num < player_two_num:
	print("Player {} wins with score of {}".format(player_two, player_two_num))
else:
	print("Even")
