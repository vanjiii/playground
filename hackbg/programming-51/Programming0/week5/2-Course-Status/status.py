
def status_count(students):
	#students is list of maps
	result = {
		"finalized" : [],
		"not_finalized" : []
	}

	for student in students:
		if student["status"] == "finalized":
			result["finalized"] += [student["name"]]
		else:
			result["not_finalized"] += [student["name"]]

	return result

students = [{
              "name": "RadoRado",
              "status": "not_finalized"
            }, {
              "name": "Ivo",
              "status": "finalized"
            }, {
              "name": "Genadi",
              "status": "finalized"
            }]
print(status_count(students))