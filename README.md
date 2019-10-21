# Graphql Dotnet Timespan Bug

This repository is to demonstrate an issue with Seconds to Timespan type.

## Instructions

1. `dotnet watch run` (or start the debug task on VS Code)
2. Navigate to `http://localhost:5000`
3. Run the `Get Item` operation detailed below to see expected result
    ```
    {
        "data": {
            "getItem": {
                "intField": 1000,
                "timeSpanField": 30600
            }
        }
    }
    ```
4. Run the `Set Item, No Query Variables` operation detailed below to see expected result
    ```
    {
        "data": {
            "setItem": {
                "intField": 500,
                "timeSpanField": 1500
            }
        }
    }
    ```
5. Run the `Set Item, With Query Variables` operation detailed below to see expected (incorrect) result
    ```
    {
        "data": {
            "setItem": {
                "intField": 2000,
                "timeSpanField": 0
            }
        }
    }
    ```

## Operations

### Get Item

```text
query {
  getItem {
    intField
    timeSpanField
  }
}
```

### Set Item, No Query Variables

```text
mutation {
  setItem(input: {
    intField: 500,
    timeSpanField: 1500
  }) {
    intField
    timeSpanField
  }
}
```

### Set Item, With Query Variables

```text
mutation($input: ItemInputType!) {
  setItem(input: $input) {
    intField
    timeSpanField
  }
}
```

and Query Variables of

```text
{
  "input": {
    "intField": 2000,
    "timeSpanField": 1500
  }
}
```
