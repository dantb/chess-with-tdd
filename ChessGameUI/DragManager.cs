using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ChessGameUI
{
    public class DragManager
    {
        Button _dragSender;
        Image _dragSenderImage;
        Button _dragTarget;
        Image _dragTargetImage;
        DragOperation _dragOperation;


        public bool InDrag = false;

        internal void BeginDrag(Button button, MouseEventArgs e)
        {
            _dragOperation = new DragOperation(button);
            //_dragSender = button;
            //_dragSenderImage = button.Content as Image;
            InDrag = true;
        }

        internal void ButtonDrop(Button button, MouseEventArgs e)
        {
            if (button == _dragOperation.Target?.Button)
            {
                if (button.Content is Image)
                {

                    Debug.Print("Button Drop image to drag target");
                    _dragOperation.Target.ButtonImage.Opacity = 1;
                    _dragOperation.Source.ButtonImage = null;
                    _dragOperation = null;
                }
            }
            else
            {
                Debug.Print("Button drop anywhere else");
                _dragOperation.Source.ButtonImage.Opacity = 1;
                if (_dragOperation.Target != null)
                {
                    _dragOperation.Target.ButtonImage = _dragOperation.Target.OriginalImage;
                }
            }
            InDrag = false;
            _dragOperation = null;
        }

        internal void ButtonDragLeave(Button button, MouseEventArgs e)
        {
            if (button == _dragOperation.Target?.Button)
            {
                Debug.Print("Button Mouse leave drag target");
                //set target piece back to what it was before
                button.Content = _dragOperation.Target.OriginalImage;
                _dragOperation.Target = null;
            }
            else if (button == _dragOperation.Source.Button)
            {
                Debug.Print("Button Mouse leave drag target");
                //set target piece back to what it was before
                _dragOperation.Source.ButtonImage.Opacity = 0.5;
            }
        }

        internal void ButtonDragEnter(Button button, MouseEventArgs e)
        {
            if (button != _dragOperation.Source.Button)
            {
                Debug.Print("Button Mouse enter not drag source");
                DragButtonTarget theTargetButton = new DragButtonTarget(button);
                Image sourceImageClone = new Image
                {
                    Source = _dragOperation.Source.ButtonImage.Source.Clone(),
                    Opacity = 0.5                    
                };
                theTargetButton.ButtonImage = sourceImageClone;
                //set new target
                _dragOperation.Target = theTargetButton;
            }
            else
            {
                _dragOperation.Source.ButtonImage.Opacity = 1;
            }
        }
    }

    public class DragOperation
    {
        public DragOperation(Button dragSource)
        {
            Source = new DragButtonSource(dragSource);
        }

        /// <summary>
        /// Square that is the source of the drag, cannot be changed during one drag operation.
        /// </summary>
        public DragButtonSource Source { get; }
        /// <summary>
        /// Target square for the drag, can be changed in one drag operation.
        /// </summary>
        public DragButtonTarget Target { get; set; }
    }

    public class DragButtonSource
    {
        public DragButtonSource(Button button)
        {
            Button = button;
        }

        public Button Button { get; }
        public Image ButtonImage
        {
            get
            {
                return (Image) Button.Content;
            }
            set
            {
                Button.Content = value;
            }
        }
    }

    public class DragButtonTarget
    {
        public DragButtonTarget(Button button)
        {
            Button = button;
            OriginalImage = button.Content as Image;
        }

        public Button Button { get; }
        public Image ButtonImage
        {
            get
            {
                return (Image) Button.Content;
            }
            set
            {
                Button.Content = value;
            }
        }
        public Image OriginalImage { get; }
    }
}
