SELECT * FROM "day"
	
	SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, dayMeal as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1
	
	SELECT * FROM dayMeal
	
	SELECT * FROM foodItem

    SELECT * FROM "day"
	
	SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, dayMeal as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1

"INSERT INTO \"meal\" (\"mealType\", \"intUserID\") VALUES (lunch, @intUserID) RETURNING \"intMealID\""
	
	INSERT INTO public."foodMeal"(
	"intMealID", "intFoodItemID")
	VALUES (1, 3), (1, 5);
	
	SELECT * FROM day WHERE \"intUserID\" =
	
	SELECT * FROM "foodItem"


    SELECT fi."intFoodItemID", fi."strName", fi."intCalories", fi."strBrandName"
FROM "foodItem" fi, "foodMeal" fm, "meal" me
WHERE me."intUserID" = 1
AND fm."intMealID" = 1
AND fm."intFoodItemID" = fi."intFoodItemID"
AND fm."intMealID" = me."intMealID"


	SELECT me."intMealID", me."mealType", me."intUserID"
	FROM meal as me, "dayMeal" as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = dm."intDayID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1


    SELECT * FROM "day"
	INSERT INTO public.day(
		"dtmDate", "intCalsLeft", "intUserID")
		VALUES (CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 1), 1),
		(CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 2), 2);

SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, "dayMeal" as dm, "day" as d
WHERE me."intMealID" = dm."intMealID"
AND d."intDayID" = dm."intDayID"
AND d."intDayID" = 1
AND me."intUserID" = 1

INSERT INTO public."exerciseType"(
	"muscleGroup", equipment, "intCaloriesBurned", "ysnAccessibility", "intTime", intensity)
	VALUES ('arms', 'dumbbells', 250, false, 60, 'med');


SELECT unnest(enum_range(NULL::equipment))
SELECT unnest(enum_range(NULL::muscleGroup))
SELECT unnest(enum_range(NULL::intensity))