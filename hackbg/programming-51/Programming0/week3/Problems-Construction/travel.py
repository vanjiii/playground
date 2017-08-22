def travel_cost(travels):
	ticket_price = 1
	line_price = 23
	all_lines = 50
	number_of_lines = len(travels)
	busy_line = 0
	sum_of_all = 0
	is_all_lines_need = False


	if number_of_lines == 1:
		if travels[0] < line_price:
			print("Maria uses one line and has no need for a card!")
		else:
			print("Maria uses one line and need a card for this line!")
	else:
		for travel in travels:
			if travel * ticket_price > all_lines:
				is_all_lines_need = True
				break
			if travel * ticket_price >= line_price:
				busy_line += ticket_price
				sum_of_all += travel * ticket_price
			else:
				sum_of_all += travel * ticket_price

			if sum_of_all > 50:
				is_all_lines_need = True
				break

		if is_all_lines_need == True:
			print("Maria need a card for all lines!!!")
		else:
			print("Maria need {} card/s of max of {} lines of use for her stay is Sofia!".format(busy_line, number_of_lines))


#main
travel_cost([28, 5])
#travel_cost([22])
#travel_cost([30, 28, 55])