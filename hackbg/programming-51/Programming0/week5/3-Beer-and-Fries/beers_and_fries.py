def max_score(beers, fries):
    index = 0
    max_sum = 0
    beers = sorted(beers)
    fries = sorted(fries)

    while index < len(beers):
        max_sum += beers[index] * fries[index]
        index += 1
    
    return max_sum

print(max_score([1000, 1010, 1020, 1030, 1040], [834, 500, -1, 0, 60]))
