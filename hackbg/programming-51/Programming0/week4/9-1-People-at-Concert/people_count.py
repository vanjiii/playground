
def get_people_count(activity):
	peoples = {}

	for people in activity:
		if people in peoples:
			peoples[people] += 1
		else:
			peoples[people] = 1

	return len(peoples)

print(get_people_count(["Rado", "Ivo", "Maria", "Anneta", "Rado", "Rado", "Anneta", "Ivo", "Maria", "Rado"]))