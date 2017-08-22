
def calculate_coins(money):
	coins = { 
	1: 0, 
	2: 0, 
	100: 0, 
	5: 0, 
	10: 0, 
	50: 0, 
	20: 0
	} 

	while money > 0.0:
		if money >= 1.00:
			money -= 1.00
			money = round(money, 2)
			coins[100] += 1
		elif money >= 0.50:
			money -= 0.50
			money = round(money, 2)
			coins[50] += 1
		elif money >= 0.20:
			money -= 0.20
			money = round(money, 2)
			coins[20] += 1
		elif money >= 0.10:
			money -= 0.10
			money = round(money, 2)
			coins[10] += 1
		elif money >= 0.05:
			money -= 0.05
			money = round(money, 2)
			coins[5] += 1
		elif money >= 0.02:
			money -= 0.02
			money = round(money, 2)
			coins[2] += 1
		else:
			money -= 0.01
			money = round(money, 2)
			coins[1] += 1
		#print(round(money, 2))
	return coins

print(calculate_coins(8.94))