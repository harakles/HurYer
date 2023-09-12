
function CaseValidate() {
    const Form = document.getElementById("FormAuth");
    Form.submit();
}

(function () {
    // Full Toolbar
    // --------------------------------------------------------------------
    const fullToolbar = [
        [
            {
                font: []
            },
            {
                size: []
            }
        ],
        ['bold', 'italic', 'underline', 'strike'],
        [
            {
                color: []
            },
            {
                background: []
            }
        ],
        [
            {
                script: 'super'
            },
            {
                script: 'sub'
            }
        ],
        [
            {
                header: '1'
            },
            {
                header: '2'
            },
            'blockquote',
            'code-block'
        ],
        [
            {
                list: 'ordered'
            },
            {
                list: 'bullet'
            },
            {
                indent: '-1'
            },
            {
                indent: '+1'
            }
        ],
        [{ direction: 'rtl' }],
        ['link', 'formula'],
        ['clean']
    ];
    const halfEditor = new Quill('#half-editor', {
        bounds: '#half-editor',
        placeholder: 'Medya detay metni giriniz',
        modules: {
            formula: true,
            toolbar: fullToolbar
        },
        theme: 'snow'
    });
    const hiddenInput = document.getElementById('Quote');

    halfEditor.on('text-change', function () {
        hiddenInput.value = halfEditor.root.innerHTML;
    });
})();

(function () {
    // Full Toolbar
    // --------------------------------------------------------------------
    const fullToolbar = [
        [
            {
                font: []
            },
            {
                size: []
            }
        ],
        ['bold', 'italic', 'underline', 'strike'],
        [
            {
                color: []
            },
            {
                background: []
            }
        ],
        [
            {
                script: 'super'
            },
            {
                script: 'sub'
            }
        ],
        [
            {
                header: '1'
            },
            {
                header: '2'
            },
            'blockquote',
            'code-block'
        ],
        [
            {
                list: 'ordered'
            },
            {
                list: 'bullet'
            },
            {
                indent: '-1'
            },
            {
                indent: '+1'
            }
        ],
        [{ direction: 'rtl' }],
        ['link', 'formula'],
        ['clean']
    ];
    const fullEditor = new Quill('#full-editor', {
        bounds: '#full-editor',
        placeholder: 'Medya detay metni giriniz',
        modules: {
            formula: true,
            toolbar: fullToolbar
        },
        theme: 'snow'
    });
    const hiddenInput = document.getElementById('TextEditor');

    fullEditor.on('text-change', function () {
        hiddenInput.value = fullEditor.root.innerHTML;
    });
})();