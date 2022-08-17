﻿function addProduct() {
    document.querySelector('#ccc').insertAdjacentHTML(
        'afterbegin',
        `<div class="products-i rounded">
                            <div class="products-bookmarking">
                                <button onclick="addProduct().apply(this)" data-mul data-disable="true" class="delete-bookmark" data-remote="true" data-method="put">
                                    <span>Seçilmişlərə əlavə et</span>
                                </button>
                            </div>
                            <a target="_blank" class="products-link">
                                <div class="products-top">
                                    <img alt="Mercedes Bens" loading="lazy" src="/images/merc.jpg">
                                    <div class="products-paid">
                                        <span class="featured-icon"></span>
                                        <span class="vipped-icon"></span>
                                    </div>
                                </div>
                                <div class="products-price-container">
                                    <div class="products-price">
                                        <span class="price-val">15 000</span>
                                        <span class="price-cur">AZN</span>
                                    </div>
                                </div>
                                <div class="products-name">Mercedes Bens</div>
                                <div class="products-created">Mingəçevir, bugün, 22:00</div>
                            </a>
                        </div>`
    )

}