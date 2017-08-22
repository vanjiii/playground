
def winter_is_coming(seasons):
	#seasons = ["winter", "summer", "summer", "summer", "spring", "srping"]
	index = len(seasons) - 1

	count = 1
	while index >= 0:

		if seasons[index] == "winter":
			return False

		if count == 5:
			return True

		count += 1
		index -= 1


print(winter_is_coming(["winter", "summer", "summer", "summer", "spring", "srping"]))