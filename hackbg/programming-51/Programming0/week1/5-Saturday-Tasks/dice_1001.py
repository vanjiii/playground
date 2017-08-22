'''
В програма dice_1001.py напишете програма, която симулира тази игра, играейки заровете на Иван и Мария.

Програмата ще трябва да отпечатва при всяко хвърляне, колко е сумата от зарчетата и временния резултат за играча.
Когато има победител, програмата трябва да го отпечата и да спре.
'''

from random import randint

mariq = "Mariq"
ivan = "Ivan"

mariq_point = 1001
ivan_points = 1001


while True:
	ivan_current_sum = 0
	maria_current_sum = 0
	i = 0

	while i < 6:
		num = randint(1, 6)
		print("Mariq has {}".format(num)) 
		maria_current_sum += num

		num = randint(1, 6)
		print("Ivan has {}".format(num)) 
		ivan_current_sum += num

		i += 1

	if mariq_point > 0:
		mariq_point = mariq_point - maria_current_sum
	else:
		mariq_point = mariq_point + maria_current_sum
	
	if ivan_points > 0:
		ivan_points = ivan_points - ivan_current_sum
	else:
		ivan_points = ivan_points + ivan_current_sum

	print("Mariq has left: " + str(mariq_point))
	print("Ivan has left: " + str(ivan_points))
	if mariq_point == 0:
		print("{} has won!".format(mariq))
		break
	if ivan_points == 0:
		print("{} has won!".format(ivan))
		break

if mariq_point == ivan_points:
	print("Damn that luck!")
