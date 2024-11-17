const selectHeader = document.querySelector('.select-header');
const selectOptions = document.querySelector('.select-options');
const btnToggle = document.querySelector('.btn-toggle');
const btnClose = document.querySelector('.btn-close');
const btnEnter = document.querySelector('.btn-enter');
const selectPlaceholder = document.querySelector('.select-placeholder');
let selectedOption = null;

// Função para abrir/fechar o menu de opções
selectHeader.addEventListener('click', () => {
    const isOptionsVisible = selectOptions.style.display === 'block';
    selectOptions.style.display = isOptionsVisible ? 'none' : 'block';
    
    // Alterna a classe 'open' para o botão de toggle, fazendo a seta rotacionar
    btnToggle.classList.toggle('open', !isOptionsVisible);
});

// Seleciona uma opção ao clicar
selectOptions.addEventListener('click', (event) => {
    if (event.target.tagName === 'LI') {
        selectedOption = event.target.textContent;
        selectPlaceholder.textContent = selectedOption; // Atualiza o placeholder
        selectOptions.style.display = 'none';
        btnToggle.classList.remove('open');
    }
});

// Ação ao clicar no botão "Entrar"
btnEnter.addEventListener('click', () => {
    if (selectedOption) {
        // Verifica a opção selecionada e redireciona
        if (selectedOption === 'Colaborador') {
            window.location.href = 'login2.html'; // Redireciona para a página do colaborador
        } else if (selectedOption === 'Hóspede') {
            window.location.href = 'cliente.html'; // Redireciona para a página de login do hóspede
        }
    } else {
        alert('Por favor, selecione uma opção antes de entrar.');
    }
});

// Função de limpar (fechar) a seleção e resetar a opção
btnClose.addEventListener('click', () => {
    selectedOption = null;
    selectPlaceholder.textContent = 'Selecione a opção'; // Reseta o placeholder
    selectOptions.style.display = 'none'; // Fecha o menu
    btnToggle.classList.remove('open'); // Remove a classe de "aberto"
});
