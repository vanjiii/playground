def forecast(days):
    snow = 0
    rain = 0
    sunny = 0

    for day in days:
        if day == "sunshine":
            sunny += 1
        elif day == "rain":
            rain += 1
        else:
            snow += 1

    if snow > rain and snow > sunny:
        return "snow"
    elif rain > snow and rain > sunny:
        return "rain"
    elif sunny > rain and sunny > snow:
        return "sunshine"
    elif sunny == rain and sunny != snow:
        return "snow"
    elif sunny == snow and sunny != rain:
        return "rain"
    elif rain == snow and rain != sunny:
        return "sunshine"
    else:
        return days[len(days) - 1]

