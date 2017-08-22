

def on_budget(books, budget):
	#books - list of int
	#budget - int
	result = {
		"books_on_budget": 0,
		"loan" : 0
	}

	books = sorted(books)

	for price_book in books:
		if price_book < budget:
			budget -= price_book
			#print(price_book)
			#print("temp budget: " + str(budget))
			result["books_on_budget"] += 1
		else:
			result["loan"] += price_book
			#print(price_book)

	result["loan"] -= budget

	return result

print(on_budget([0, 10, 100, 5, 3, 8, 25], 35))