mergeInto(LibraryManager.library, {
    LogToConsole: function (message) {
      ReactUnityWebGL.LogToConsole(Pointer_stringify(message));
    },
    CreateCard: function (card) {
      ReactUnityWebGL.CreateCard(Pointer_stringify(card));
    },
  });