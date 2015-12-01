  (script-fu-register
            "Neon-Text-Creator"                        ;func name
            "Neon Text"                                  ;menu label
            "Creates a haze effect with lightened interior text
	     to simulate glow."              ;description
            "Colin Hogue"                             ;author
            "copyright 2015 (can I do this?)"        ;copyright notice
            "November 10, 2015"                          ;date created
            ""                     ;image type that the script works on
            SF-STRING      "Text"          "Replace This"   ;a string variable
            SF-FONT        "Font"          "Sans Bold Italic"    ;a font variable
            SF-ADJUSTMENT  "Font size"     '(50 1 1000 1 10 0 1)
                                                        ;a spin-button
            SF-COLOR       "Color"         '(0 175 3)     ;color variable
 	    SF-ADJUSTMENT  "Buffer amount" '(35 0 100 1 10 1 0)
                                                        ;a slider
  )
  (script-fu-menu-register "Neon-Text-Creator" "<Image>/File/Create/Text")
  (define (Neon-Text-Creator inText inFont inFontSize inTextColor inBufferAmount)
    (let*
      (
        ; define our local variables
        ; create a new image:
        (theImageWidth  10)
        (theImageHeight 10)
	(i 0)
        (theImage)
        (theImage
                  (car
                      (gimp-image-new
                        theImageWidth
                        theImageHeight
                        RGB
                      )
                  )
        )
        (theText)             ;a declaration for the text
        (theBuffer)           ;create a new layer for the image
        (theLayer
                  (car
                      (gimp-layer-new
                        theImage
                        theImageWidth
                        theImageHeight
                        RGB-IMAGE
                        "layer 1"
                        100
                        NORMAL
                      )
                  )
        )
        (theGlow)
        (theHighlight)

	; brush variables
	(hardness 20.0)
	(size 200)
	(path (cons-array 4 'double)); when set will hold the stroke path

      ) ;end of our local variables
      (gimp-image-add-layer theImage theLayer 0)
      (gimp-context-set-background '(255 255 255) )
      (gimp-context-set-foreground inTextColor)
	
      (gimp-drawable-fill theLayer BACKGROUND-FILL)
      (gimp-item-set-visible theLayer FALSE)
      (set! theText
                    (car
                          (gimp-text-fontname
                          theImage theLayer
                          0 0
                          inText
                          0
                          TRUE
                          inFontSize PIXELS
                          "Sans")
                      )
        )
      (set! theImageWidth   (car (gimp-drawable-width  theText) ) )
      (set! theImageHeight  (car (gimp-drawable-height theText) ) )
      (set! theBuffer (* theImageHeight (/ inBufferAmount 100) ) )
      (set! theImageHeight (+ theImageHeight theBuffer theBuffer) )
      (set! theImageWidth  (+ theImageWidth  theBuffer theBuffer) )
      (gimp-image-resize theImage theImageWidth theImageHeight 0 0)
      (gimp-floating-sel-to-layer theText)
      (gimp-layer-resize theLayer theImageWidth theImageHeight 0 0)
      (gimp-layer-set-offsets theText theBuffer theBuffer)
	
     	(set! theGlow (car (gimp-layer-new-from-visible theImage theImage "test")))
	(set! theHighlight (car (gimp-layer-new-from-visible theImage theImage "test2")))
        (gimp-image-add-layer theImage theGlow 2)
	(gimp-image-add-layer theImage theHighlight 4)
	(gimp-item-set-visible theText FALSE)

	;initialize the path
	(aset path 0 0)
	(aset path 1 (/ theImageHeight 2))
	(aset path 2 theImageWidth)
	(aset path 3 (/ theImageHeight 2))
	
	;Set theHighlight as Active
	;(gimp-image-set-active-layer theImage theGlow)

	;Select around the text
	(gimp-image-select-item theImage 2 theGlow)
	
	;Select a Brush
	(gimp-context-set-brush "myBrush") ;set a brush to edit

		;start the haze loop
	(while (< i 5)
		(gimp-selection-grow theImage 1); grow the selection by one pixel
		;stroke

		(gimp-pencil theGlow 4 path)
		(set! i(+ i 1))
	); This should run 4 times

	;Select around the text
	(gimp-image-select-item theImage 2 theHighlight)
	
	;Invert the Selection
	;(gimp-selection-invert theImage)

	;Set the Foreground to white
	(gimp-context-set-foreground '(255 255 255))
	
	(set! i 0)
	
	(gimp-selection-shrink theImage 1)

	;Start the Highlight loop
	(while ( = (car (gimp-selection-is-empty theImage)) FALSE);If the selection is too small and selects nothing, exit the loop 
		
		;stroke onto the foremost layer, theGlow
		(gimp-pencil theGlow 4 path)
		(set! i(+ i 1))
		(gimp-selection-shrink theImage 1)
	); Should run until it hits the center

      (gimp-display-new theImage)
      (list theImage theLayer theText theGlow)
    )
  )